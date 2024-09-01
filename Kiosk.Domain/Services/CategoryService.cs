using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEK.Core.Domain.BusinessObjects;
using TEK.Core.Service.Interfaces;
using TEK.Core.UoW;

namespace TEK.Payment.Domain.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ICategoryService" />
    public class CategoryService : ICategoryService
    {
        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Gets or sets the external system service.
        /// </summary>
        /// <value>The external system service.</value>
        private readonly IHospitalSystemService _hospitalSystemService;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryService" /> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public CategoryService(IUnitOfWork unitOfWork,
            IHospitalSystemService hospitalSystemService,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _hospitalSystemService = hospitalSystemService;
            _mapper = mapper;
        }

        public async Task<List<CategoryViewModel>> GetAll()
        {
            var categories = new List<CategoryViewModel>();
            // Find patient in Tekmedi System
            var response = await _hospitalSystemService.GetRawCategories(new GetRawCategoryRequest
            {
                Type = "DV"
            });

            categories.AddRange(response.Result.Select(_mapper.Map<GetRawCategoryData, CategoryViewModel>).ToList());

            response = await _hospitalSystemService.GetRawCategories(new GetRawCategoryRequest
            {
                Type = "DR"
            });

            categories.AddRange(response.Result.Select(_mapper.Map<GetRawCategoryData, CategoryViewModel>).ToList());

            return categories;
        }
    }
}
