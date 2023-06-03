using KoreaCommon.Fish.해양수산부.For조합창고품목별재고현황;
using KoreaCommon.Model;
using Microsoft.EntityFrameworkCore;

namespace KoreaCommon.Fish.해양수산부
{
    public interface IInventoryStausToDb
    {
        Task APIToDb(DateTime startDate, DateTime endDate);
    }
    public class 수협APIToDbManager : IInventoryStausToDb
    {
        private readonly 조합창고품목별재고현황API _조합창고품목별재고현황;
        private readonly 수협DbContext _수협DbContext;
        
        public 수협APIToDbManager(조합창고품목별재고현황API 조합창고품목별재고현황, 수협DbContext 수협DbContext) 
        {
            _조합창고품목별재고현황 = 조합창고품목별재고현황;
            _수협DbContext = 수협DbContext;
        }
        public async Task APIToDb(DateTime startDate, DateTime endDate)
        {
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                string dateString = date.ToString("yyyyMMdd");
                var TotalCount = await _조합창고품목별재고현황.PrintTotalCount(dateString);
                var EndPage = TotalCount / 100 + 1;
                for(int i = 1; i <= EndPage; i++)
                {
                    var Result = await _조합창고품목별재고현황.Get조합창고품목별재고현황정보(dateString, 100, i);
                    await ItemsToDb(Result);
                }
            }
        }
        private async Task ItemsToDb(조합창고품목별재고현황정보 Result)
        {
            foreach(var item in Result.ResponseJson.Body.Item)
            {
                var 조합코드 = item.MxtrCode.ToString();
                var 창고코드 = item.WrhousCode.ToString();
                var 상품코드 = item.MprcStdCode.ToString();
                var 기준일자 = item.StdrDe.ToString();

                var 조합 = await _수협DbContext.Set<수산협동조합>().FirstOrDefaultAsync(e => e.Code.Equals(조합코드));
                var 창고 = await _수협DbContext.Set<수산창고>().FirstOrDefaultAsync(e => e.Code.Equals(창고코드) && e.수협Id.Equals(조합코드));
                var 상품 = await _수협DbContext.Set<수산품>().FirstOrDefaultAsync(e => e.Code.Equals(상품코드) && e.창고Id.Equals(창고코드));

                if (조합 == null)
                {
                    await _수협DbContext.AddAsync(new 수산협동조합 { Code = 조합코드, Name = item.MxtrNm.ToString()});
                    await _수협DbContext.SaveChangesAsync();
                    조합 = await _수협DbContext.Set<수산협동조합>().FirstOrDefaultAsync(e => e.Code.Equals(조합코드));
                }
                if (창고 == null)
                {
                    await _수협DbContext.AddAsync(new 수산창고 { 수협Id= 조합.Code, Code = 창고코드, Name = item.WrhousNm.ToString() });
                    await _수협DbContext.SaveChangesAsync();
                    창고 = await _수협DbContext.Set<수산창고>().FirstOrDefaultAsync(e => e.Code.Equals(창고코드));
                }
                if (상품 == null)
                {
                    await _수협DbContext.AddAsync(new 수산품 { 창고Id= 창고.Code, 수협Id = 조합.Code, Code = 상품코드, Name = item.MprcStdCodeNm.ToString() });
                    await _수협DbContext.SaveChangesAsync();
                    상품 = await _수협DbContext.Set<수산품>().FirstOrDefaultAsync(e => e.Code.Equals(상품코드));
                }
                var newData = await _수협DbContext.Set<수산품별재고현황>().Where(e => e.수산품Id.Equals(상품.Code) &&
                                                                                 e.수협Id.Equals(조합.Code) &&
                                                                                 e.창고Id.Equals(창고.Code) &&
                                                                                 e.date.Equals(기준일자) &&
                                                                                 e.Quantity.Equals(item.InvntryQy)).FirstOrDefaultAsync();
                if(newData == null)
                {
                    newData = new 수산품별재고현황 { 수산품Id = 상품.Id, 창고Id = 창고.Code, 수협Id = 조합.Code, date=item.StdrDe, Quantity=item.InvntryQy, Name=item.MprcStdCodeNm };
                    await _수협DbContext.AddAsync(newData);
                    await _수협DbContext.SaveChangesAsync();
                }
                
            }
        }
    }
}
