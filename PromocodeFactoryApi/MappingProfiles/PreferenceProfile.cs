﻿using AutoMapper;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Service.DTO.PromocodeManagment;

namespace PromocodeFactoryApi.MappingProfiles
{
    public class PreferenceProfile:Profile
    {
        public PreferenceProfile()
        {
            CreateMap<Preference, PreferenceDTO>();
        }
    }
}
