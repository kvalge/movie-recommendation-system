using DAL.Repositories;
using DAL.Repositories.Interfaces;
using DAL.UOW.Interfaces;

namespace DAL.UOW;

public class AppUow : BaseUow<AppDbContext>, IAppUow
{
    public AppUow(AppDbContext uowDbContext) : base(uowDbContext)
    {
    }
    
    private ICastAndCrewRepository? _castAndCrewRepository;
    public ICastAndCrewRepository CastAndCrewRepository =>
        _castAndCrewRepository ??= new CastAndCrewRepository(UowDbContext);
    
    private ICountryRepository? _countryRepository;
    public ICountryRepository CountryRepository =>
        _countryRepository ??= new CountryRepository(UowDbContext);
    
    private IGenreRepository? _genreRepository;
    public IGenreRepository GenreRepository =>
        _genreRepository ??= new GenreRepository(UowDbContext);
    
    private IMovieRepository? _movieRepository;
    public IMovieRepository MovieRepository =>
        _movieRepository ??= new MovieRepository(UowDbContext);
    
    private IRatingRepository? _ratingRepository;
    public IRatingRepository RatingRepository =>
        _ratingRepository ??= new RatingRepository(UowDbContext);
    
    private IRatingValueRepository? _ratingValueRepository;
    public IRatingValueRepository RatingValueRepository =>
        _ratingValueRepository ??= new RatingValueRepository(UowDbContext);
    
    private IReviewRepository? _reviewRepository;
    public IReviewRepository ReviewRepository =>
        _reviewRepository ??= new ReviewRepository(UowDbContext);
    
    private IMovieRecommendationRepository? _movieRecommendationRepository;
    public IMovieRecommendationRepository MovieRecommendationRepository => 
        _movieRecommendationRepository ??= new MovieRecommendationRepository(UowDbContext);
}