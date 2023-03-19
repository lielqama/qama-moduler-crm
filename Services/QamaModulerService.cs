using AutoMapper;
using Newtonsoft.Json.Linq;
using QamaCoreShared.Entities.Priority;
using QamaCoreShared.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using modulercrm.Entities.Moduler;


namespace modulercrm.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IQamaModulerService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<List<Customer>> getCustomer();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        Task<List<Product>> getProduct();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public class QamaModulerService : IQamaModulerService
        {
            private readonly IPriorityService _priorityService;
            private readonly ILoggerService _logger;
            private readonly IMapper _mapper;

            /// <summary>
            /// 
            /// </summary>
            /// <param name="priorityFactory"></param>
            /// <param name="modulerService"></param>
            /// <param name="logger"></param>
            /// <param name="mapper"></param>
            public QamaModulerService(IPriorityFactory priorityFactory,  ILoggerService logger, IMapper mapper)
            {
                _priorityService = priorityFactory.GetInstance(string.Empty);
                _logger = logger;
                _mapper = mapper;
            }



            /// <summary>
            /// list of product
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            public async Task<List<Product>> getProduct()
            {
                var logid = $"LOGPART - {DateTime.Now}";

                _priorityService.SetLogId(logid);

                List<LOGPART> logpart = await _priorityService.GetListAsync<LOGPART>("LOGPART", -1,null, "PARTNAME, PARTDES, BARCODE", null);

                _logger.Debug(logid, "priority model", logpart);



                List<Product> part = _mapper.Map<List<Product>>(logpart);

                _logger.Debug(logid, "converted model", part);

               
                return part;

              

            }



            /// <summary>
            /// list of customers
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            public async Task<List<Customer>> getCustomer()
            {
                var logid = $"CUSTOMERS - {DateTime.Now}";

                _priorityService.SetLogId(logid);

               List<CUSTOMERS> customers = await _priorityService.GetListAsync<CUSTOMERS>("CUSTOMERS", -1,null, $"CUSTNAME, CUSTDES, WTAXNUM,STATEA, PHONE, ADDRESS, ADDRESS2, SPEC2, EMAIL ");

                _logger.Debug(logid, "priority model", customers);

                List<Customer> customers1 = _mapper.Map<List<Customer>>(customers);

                _logger.Debug(logid, "converted model", customers1);

                return customers1;

            }



        }
    }
}