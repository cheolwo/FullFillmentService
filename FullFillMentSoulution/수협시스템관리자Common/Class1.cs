using IdentityCommon.Services;
using KoreaCommon.Services;
using OrderClient.Services;
using OrderCommon.Services.API;
using WarehouseCommon.APIService;

namespace 수협시스템관리자Common
{
    public class 수협장Manager
    {
        private readonly AccountService _AccountService;
        private readonly 수산창고APIService _수산창고APIService;
        private readonly 수산품APIService _수산품APIService;
        private readonly 수산품별재고현황APIService _수산품별재고현황APIService;
        private readonly 수산협동조합APIService _수산협동조합APIService;
        private readonly 주문APIService _주문APIService;
        private readonly 판매자APIService _판매자APIService;
        private readonly 판매자상품APIService _판매자상품APIService;
        private readonly 창고APIService _창고APIService;
        private readonly 창고상품APIService _창고상품APIService;
        private readonly 출고상품APIService _출고상품APIService;
        private readonly 적재상품APIService _적재상품APIService;
        private readonly 입고상품APIService _입고상품APIService;

        public 수협장Manager(
            AccountService accountService,
            수산창고APIService 수산창고APIService,
            수산품APIService 수산품APIService,
            수산품별재고현황APIService 수산품별재고현황APIService,
            수산협동조합APIService 수산협동조합APIService,
            주문APIService 주문APIService,
            판매자APIService 판매자APIService,
            판매자상품APIService 판매자상품APIService,
            창고APIService 창고APIService,
            창고상품APIService 창고상품APIService,
            출고상품APIService 출고상품APIService,
            적재상품APIService 적재상품APIService,
            입고상품APIService 입고상품APIService)
        {
            _AccountService = accountService;
            _수산창고APIService = 수산창고APIService;
            _수산품APIService = 수산품APIService;
            _수산품별재고현황APIService = 수산품별재고현황APIService;
            _수산협동조합APIService = 수산협동조합APIService;
            _주문APIService = 주문APIService;
            _판매자APIService = 판매자APIService;
            _판매자상품APIService = 판매자상품APIService;
            _창고APIService = 창고APIService;
            _창고상품APIService = 창고상품APIService;
            _출고상품APIService = 출고상품APIService;
            _적재상품APIService = 적재상품APIService;
            _입고상품APIService = 입고상품APIService;
        }
    }
}