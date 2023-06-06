﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using 창고Common;

namespace WarehouseCommon.APIService
{
    public class 창고ApiService
    {
        private readonly HttpClient _httpClient;

        public 창고ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<창고>> GetAll창고()
        {
            var response = await _httpClient.GetAsync("api/창고");
            response.EnsureSuccessStatusCode();
            var 창고List = await response.Content.ReadFromJsonAsync<List<창고>>();
            return 창고List;
        }

        public async Task<창고> Get창고ById(string id)
        {
            var response = await _httpClient.GetAsync($"api/창고/{id}");
            if (response.IsSuccessStatusCode)
            {
                var 창고 = await response.Content.ReadFromJsonAsync<창고>();
                return 창고;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception("창고 조회 중에 오류가 발생했습니다.");
            }
        }

        public async Task<창고> Get창고ByAddress(string address)
        {
            var response = await _httpClient.GetAsync($"api/창고/getByAddress?address={address}");
            if (response.IsSuccessStatusCode)
            {
                var 창고 = await response.Content.ReadFromJsonAsync<창고>();
                return 창고;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception("주소로 창고 조회 중에 오류가 발생했습니다.");
            }
        }

        public async Task<창고> Get창고ByEmail(string email)
        {
            var response = await _httpClient.GetAsync($"api/창고/getByEmail?email={email}");
            if (response.IsSuccessStatusCode)
            {
                var 창고 = await response.Content.ReadFromJsonAsync<창고>();
                return 창고;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception("이메일로 창고 조회 중에 오류가 발생했습니다.");
            }
        }

        public async Task<창고> Get창고ByFaxNumber(string faxNumber)
        {
            var response = await _httpClient.GetAsync($"api/창고/getByFaxNumber?faxNumber={faxNumber}");
            if (response.IsSuccessStatusCode)
            {
                var 창고 = await response.Content.ReadFromJsonAsync<창고>();
                return 창고;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception("팩스번호로 창고 조회 중에 오류가 발생했습니다.");
            }
        }

        public async Task<창고> Get창고ByPhoneNumber(string phoneNumber)
        {
            var response = await _httpClient.GetAsync($"api/창고/getByPhoneNumber?phoneNumber={phoneNumber}");
            if (response.IsSuccessStatusCode)
            {
                var 창고 = await response.Content.ReadFromJsonAsync<창고>();
                return 창고;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception("전화번호로 창고 조회 중에 오류가 발생했습니다.");
            }
        }

        public async Task<창고> Get창고ByCode(string code)
        {
            var response = await _httpClient.GetAsync($"api/창고/getByCode?code={code}");
            if (response.IsSuccessStatusCode)
            {
                var 창고 = await response.Content.ReadFromJsonAsync<창고>();
                return 창고;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception("코드로 창고 조회 중에 오류가 발생했습니다.");
            }
        }

        public async Task<창고> Get창고ByName(string name)
        {
            var response = await _httpClient.GetAsync($"api/창고/getByName?name={name}");
            if (response.IsSuccessStatusCode)
            {
                var 창고 = await response.Content.ReadFromJsonAsync<창고>();
                return 창고;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception("이름으로 창고 조회 중에 오류가 발생했습니다.");
            }
        }

        public async Task<창고> Get창고ByIdWith창고상품(string id)
        {
            var response = await _httpClient.GetAsync($"api/창고/{id}/with창고상품");
            if (response.IsSuccessStatusCode)
            {
                var 창고 = await response.Content.ReadFromJsonAsync<창고>();
                return 창고;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception("창고상품 정보를 함께 조회하는 중에 오류가 발생했습니다.");
            }
        }

        public async Task<창고> Get창고ByIdWith입고상품(string id)
        {
            var response = await _httpClient.GetAsync($"api/창고/{id}/with입고상품");
            if (response.IsSuccessStatusCode)
            {
                var 창고 = await response.Content.ReadFromJsonAsync<창고>();
                return 창고;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception("입고상품 정보를 함께 조회하는 중에 오류가 발생했습니다.");
            }
        }

        public async Task<창고> Get창고ByIdWith적재상품(string id)
        {
            var response = await _httpClient.GetAsync($"api/창고/{id}/with적재상품");
            if (response.IsSuccessStatusCode)
            {
                var 창고 = await response.Content.ReadFromJsonAsync<창고>();
                return 창고;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception("적재상품 정보를 함께 조회하는 중에 오류가 발생했습니다.");
            }
        }

        public async Task<창고> Get창고ByIdWith출고상품(string id)
        {
            var response = await _httpClient.GetAsync($"api/창고/{id}/with출고상품");
            if (response.IsSuccessStatusCode)
            {
                var 창고 = await response.Content.ReadFromJsonAsync<창고>();
                return 창고;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception("출고상품 정보를 함께 조회하는 중에 오류가 발생했습니다.");
            }
        }

        public async Task<창고> Create창고(창고 창고)
        {
            var response = await _httpClient.PostAsJsonAsync("api/창고", 창고);
            response.EnsureSuccessStatusCode();
            var created창고 = await response.Content.ReadFromJsonAsync<창고>();
            return created창고;
        }

        public async Task<창고> Update창고(string id, 창고 updated창고)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/창고/{id}", updated창고);
            if (response.IsSuccessStatusCode)
            {
                var 창고 = await response.Content.ReadFromJsonAsync<창고>();
                return 창고;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception("창고 업데이트 중에 오류가 발생했습니다.");
            }
        }

        public async Task<bool> Delete창고(string id)
        {
            var response = await _httpClient.DeleteAsync($"api/창고/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }
            else
            {
                throw new Exception("창고 삭제 중에 오류가 발생했습니다.");
            }
        }
    }
}
