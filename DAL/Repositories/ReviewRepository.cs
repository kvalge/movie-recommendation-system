using BLL.DTO;
using BLL.mappers;
using DAL.Repositories.Interfaces;
using Domain.Entities;

namespace DAL.Repositories;

public class ReviewRepository : BaseRepository<ReviewDto, Review>, IReviewRepository
{
    public ReviewRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new ReviewMapper())
    {
    }
}