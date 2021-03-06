﻿using HotelRecord.Repository.Moduls;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelRecord.BussinessLogic.Interfaces
{
    public interface IHotelChainService
    {
        IEnumerable<HotelChain> GetAllHotelChains();

        HotelChain GetHotelChain(int id);

        IEnumerable<HotelChain> GetTradition();

        IEnumerable<HotelChain> GetWorkers();

        void SaveHotelChain(HotelChain hotelChain);

        void DeleteHotelChain(int id);

        HotelChain UpdateHotelChain(HotelChain hotelChain);

    }
}
