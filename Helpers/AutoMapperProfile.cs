using AutoMapper;
using QamaCoreShared.Entities.Priority;
using QamaCoreShared.Helpers;
using ModulerCrm.Models;
using QamaCoreShared.Models.Customers;
using QamaCoreShared.Models.Payments;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using modulercrm.Entities.Moduler;

namespace ModulerCrm.Helpers
{
    /// <summary>
    /// Mapping profile
    /// </summary>
    public class AutoMapperProfile : AutoMapperProfileBase
    {
        /// mappings between model and entity objects
        public AutoMapperProfile()
        {
            CreateMap<CUSTOMERS, Customer>()
                .ForMember(x => x.CUSTNAME, opt => opt.MapFrom(y => y.CUSTNAME))
                .ForMember(x => x.CUSTDES, opt => opt.MapFrom(y => y.CUSTDES))
                .ForMember(x => x.WTAXNUM, opt => opt.MapFrom(y => y.WTAXNUM))
                .ForMember(x => x.PHONE, opt => opt.MapFrom(y => y.PHONE))
                .ForMember(x => x.STATEA, opt => opt.MapFrom(y => y.STATEA))
                .ForMember(x => x.ADDRESS, opt => opt.MapFrom(y => y.ADDRESS))
                .ForMember(x => x.SPEC2, opt => opt.MapFrom(y => y.SPEC2))
                .ForMember(x => x.ADDRESS2, opt => opt.MapFrom(y => y.ADDRESS2));

            CreateMap<LOGPART, Product>()
               .ForMember(x => x.PARTNAME, opt => opt.MapFrom(y => y.PARTNAME))
               .ForMember(x => x.PARTDES, opt => opt.MapFrom(y => y.PARTDES))
               .ForMember(x => x.BARCODE, opt => opt.MapFrom(y => y.BARCODE));


        }
    }
}
