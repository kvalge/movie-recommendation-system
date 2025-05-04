using DAL.Repositories.Interfaces;

namespace DAL.UOW.Interfaces;

public interface IAppUow : IUow
{
    ICastAndCrewRepository CastAndCrewRepository { get; }
    ICountryRepository CountryRepository { get; }
    IGenreRepository GenreRepository { get; }
    IMovieRepository MovieRepository { get; }
    IRatingRepository RatingRepository { get; }
    IRatingValueRepository RatingValueRepository { get; }
    IReviewRepository ReviewRepository { get; }
    IMovieRecommendationRepository MovieRecommendationRepository { get; }
}