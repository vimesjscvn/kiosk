using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Domain.BusinessObjects;
using Core.Service.Interfaces;
using Core.UoW;

namespace Core.Service.Implements
{
    /// <summary>
    /// </summary>
    /// <seealso cref="ICategoryService" />
    public class CategoryService : ICategoryService
    {
        /// <summary>
        ///     Gets or sets the external system service.
        /// </summary>
        /// <value>The external system service.</value>
        private readonly IHospitalSystemService _hospitalSystemService;

        /// <summary>
        ///     The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        ///     The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        ///     Initializes a new instance of the <see cref="CategoryService" /> class.
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