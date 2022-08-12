﻿
namespace PromocodeFactory.Infrastructure.Pagging
{
    public class PaggingParameters
    {
        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value > maxPageSize) ? _pageSize : value; }
        }
    }
}
