﻿using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 주문Common.DTO.판매자판매정보요약
{
    public class Create판매자판매정보요약DTO : CudDTO
    {
        public string Id { get; set; }
    }
    public class Update판매자판매정보요약DTO : CudDTO
    {
        public string Id { get; set; }
    }
    public class Delete판매자판매정보요약TO : CudDTO
    {
        public string Id { get; set; }
    }
    public class Read판매자판매정보요약DTO : ReadDto
    {
        public string Id { get; set; }
    }
}
