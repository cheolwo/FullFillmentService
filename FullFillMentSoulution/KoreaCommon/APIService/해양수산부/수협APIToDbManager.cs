using Microsoft.EntityFrameworkCore;
using 수협Common.Model;
using 수협Common.Repository;
using 해양수산부.API.For산지조합;
using 해양수산부.API.For산지조합창고;
using 해양수산부.API.For조합창고품목별재고현황;

namespace KoreaCommon.Fish.해양수산부
{
    public interface I수협창고재고상품수집
    {
        Task 수협창고재고상품ToDb(DateTime currentTime);
        Task 수협창고재고상품ToDb(string 창고id, DateTime currentTime);
    }
    public interface IInventoryStausToDb
    {
        Task APIToDb(DateTime startDate, DateTime endDate);
    }
    public interface ICollett수산창고
    {
        Task Collect수산창고(string startDate);
    }
    public class 수협APIToDbManager : IInventoryStausToDb, I수협창고재고상품수집
    {
        private readonly 조합창고품목별재고현황API _조합창고품목별재고현황;
        private readonly 산지조합API _산지조합API;
        private readonly 산지조합창고API _산지조합창고API;
        private readonly 수협DbContext _수협DbContext;
        private readonly 수산품Repository _수산품Repository;
        private readonly 수산창고Repository _수산창고Repository;

        public 수협APIToDbManager(산지조합API 산지조합API, 산지조합창고API 산지조합창고API, 조합창고품목별재고현황API 조합창고품목별재고현황, 수협DbContext 수협DbContext,
            수산품Repository 수산품Repository, 수산창고Repository 수산창고Repository)
        {
            _조합창고품목별재고현황 = 조합창고품목별재고현황;
            _산지조합API = 산지조합API;
            _산지조합창고API = 산지조합창고API;
            _수협DbContext = 수협DbContext;
            _수산품Repository = 수산품Repository;
            _수산창고Repository = 수산창고Repository;
        }
        public async Task APIToDb(DateTime startDate, DateTime endDate)
        {
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                string dateString = date.ToString("yyyyMMdd");
                var TotalCount = await _조합창고품목별재고현황.PrintTotalCount(dateString);
                var EndPage = TotalCount / 100 + 1;
                for (int i = 1; i <= EndPage; i++)
                {
                    var Result = await _조합창고품목별재고현황.Get조합창고품목별재고현황정보(dateString, 100, i);
                    await ItemsToDb(Result);
                }
            }
        }
        public async Task APIToDb(DateTime CurrentTime)
        {
            string dateString = CurrentTime.ToString("yyyyMMdd");
        }
        public async Task 수협창고재고상품ToDb(DateTime currentTime)
        {
            //var 수산품들 = await _수산품Repository.GetToList수산품이름ByDistinct();
            DateTime startDate = currentTime.AddDays(-3);
            for (DateTime date = startDate; date <= currentTime; startDate = startDate.AddDays(1))
            {
                string dateString = date.ToString("yyyyMMdd");
                var TotalCount = await _조합창고품목별재고현황.PrintTotalCount(dateString);
                if(TotalCount == 0) { continue; }
                var EndPage = TotalCount / 100 + 1;
                for (int i = 1; i <= EndPage; i++)
                {
                    var Result = await _조합창고품목별재고현황.Get조합창고품목별재고현황정보(dateString, 100, i);
                    await ItemsToDb(Result);
                }
            }
        }

        public async Task 수협창고재고상품ToDb(string 창고id, DateTime currentTime)
        {
            var 수산창고 = await _수산창고Repository.GetByIdWith수산조합(창고id);
            if(수산창고 == null) { throw new ArgumentException("없는 수산창고"); }
            if (수산창고.수협?.Name == null) { throw new ArgumentNullException(nameof(수산창고.수협.Name)); }
            if (수산창고.Name == null) { throw new ArgumentNullException(nameof(수산창고.Name)); }

            DateTime startDate = currentTime.AddDays(-3);
            for (DateTime date = startDate; date <= currentTime; startDate = startDate.AddDays(1))
            {
                string dateString = date.ToString("yyyyMMdd");
                var TotalCount = await _조합창고품목별재고현황.PrintTotalCountBy조합및창고이름(dateString, 수산창고.수협.Name, 수산창고.Name);
                if (TotalCount == 0) { continue; }
                var EndPage = TotalCount / 100 + 1;
                for (int i = 1; i <= EndPage; i++)
                {
                    var Result = await _조합창고품목별재고현황.Get조합창고품목별재고현황정보(dateString, 100, i);
                    await ItemsToDb(Result);
                }
            }
        }

        private async Task ItemsToDb(조합창고품목별재고현황정보 Result)
        {
            if (Result.ResponseJson?.Body?.Item == null) { return; }
            foreach (var item in Result.ResponseJson.Body.Item)
            {
                var 조합코드 = item.MxtrCode.ToString();
                var 창고코드 = item.WrhousCode.ToString();
                var 상품코드 = item.MprcStdCode.ToString();
                var 기준일자 = item.StdrDe.ToString();

                var 조합 = await _수협DbContext.Set<수산협동조합>().FirstOrDefaultAsync(e => e.Code.Equals(조합코드));
                var 창고 = await _수협DbContext.Set<수산창고>().FirstOrDefaultAsync(e => e.Code.Equals(창고코드));
                var 상품 = await _수협DbContext.Set<수산품>().FirstOrDefaultAsync(e => e.Code.Equals(상품코드) && e.창고Id.Equals(창고코드));

                if (조합 == null)
                {
                    await _수협DbContext.AddAsync(new 수산협동조합 { Code = 조합코드, Name = item.MxtrNm.ToString() });
                    await _수협DbContext.SaveChangesAsync();
                    조합 = await _수협DbContext.Set<수산협동조합>().FirstOrDefaultAsync(e => e.Code.Equals(조합코드));
                }
                if (창고 == null)
                {
                    await _수협DbContext.AddAsync(new 수산창고 { 수협Id = 조합.Code, Code = 창고코드, Name = item.WrhousNm.ToString() });
                    await _수협DbContext.SaveChangesAsync();
                    창고 = await _수협DbContext.Set<수산창고>().FirstOrDefaultAsync(e => e.Code.Equals(창고코드));
                }
                if (상품 == null)
                {
                    await _수협DbContext.AddAsync(new 수산품
                    {
                        창고Id = 창고.Code,
                        수협Id = 조합.Code,
                        Code = 상품코드,
                        Name = item.MprcStdCodeNm.ToString()
                    });
                    await _수협DbContext.SaveChangesAsync();
                    상품 = await _수협DbContext.Set<수산품>().FirstOrDefaultAsync(e => e.Code.Equals(상품코드));
                }
                var newData = await _수협DbContext.Set<수산품별재고현황>().Where(e => e.수산품Id.Equals(상품.Code) &&
                                                                                 e.수협Id.Equals(조합.Code) &&
                                                                                 e.창고Id.Equals(창고.Code) &&
                                                                                 e.date.Equals(기준일자) &&
                                                                                 e.Quantity.Equals(item.InvntryQy)).FirstOrDefaultAsync();
                if (newData == null)
                {
                    newData = new 수산품별재고현황
                    {
                        수산품Id = 상품.Id,
                        창고Id = 창고.Code,
                        수협Id = 조합.Code,
                        date = item.StdrDe,
                        Quantity = item.InvntryQy,
                        Name = item.MprcStdCodeNm
                    };
                    await _수협DbContext.AddAsync(newData);
                    await _수협DbContext.SaveChangesAsync();
                }

            }
        }
    }
}
