using System.Collections.Generic;
using AppMobileBackEnd.DbContexts;
using AppMobileBackEnd.Dtos.Music;
using AppMobileBackEnd.Entity;
using AppMobileBackEnd.Entity.EntityMoreMore;
using AppMobileBackEnd.PaginatedList;
using AppMobileBackEnd.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using static AppMobileBackEnd.Entity.Music;

namespace AppMobileBackEnd.Services.Implements
{
    public class SearchMusicServices : IMusicSeacrhServices
    {
        public static int PAGE_SIZE = 2;
        private readonly ApplicationMyDBContext _context;

        public SearchMusicServices(ApplicationMyDBContext context)
        {
            _context = context;
        }

        public List<SearchMusicDto> GetAllByCagetory(String NameCagetory)
        {
            var lists =
                from music in _context.musics
                join cagetoryMusic in _context.categoryMusics
                    on music.IdMusic equals cagetoryMusic.IdMusic
                select new { music, IdCagetory = cagetoryMusic.IdCategory };
            var result =
                from list in lists
                join cagetory in _context.categories on list.IdCagetory equals cagetory.IdCategory
                where cagetory.NameCategory.Equals(NameCagetory)
                orderby list.music.NumberLike
                select new SearchMusicDto
                {
                    NameMusic = list.music.NameMusic,
                    ImageMusic = list.music.ImageMusic,
                    LyrcsMusic = list.music.LyrcsMusic,
                    NumberLike = list.music.NumberLike,
                };
            return result.ToList();
        }

        public List<SearchMusicDto> SearchByArtist(string NameArtist, int? from, int? to, int page)
        {
            var lists =
                from music in _context.musics
                join artistMusic in _context.artistMusics
                    on music.IdMusic equals artistMusic.IdMusic
                select new { music, IdArtist = artistMusic.IdArtist };
            var musics =
                from list in lists
                join artist in _context.artists on list.IdArtist equals artist.IdArtist
                where artist.NameArtist.Contains(NameArtist)
                orderby list.music.NumberLike
                select new SearchMusicDto
                {
                    NameMusic = list.music.NameMusic,
                    ImageMusic = list.music.ImageMusic,
                    LyrcsMusic = list.music.LyrcsMusic,
                    NumberLike = list.music.NumberLike,
                };
            if (from.HasValue)
            {
                musics = musics.Where(r => r.NumberLike >= from);
            }
            if (to.HasValue)
            {
                musics = musics.Where(r => r.NumberLike <= to);
            }
            musics = musics.OrderBy(m => m.NumberLike);

            var result = PaginatedList<SearchMusicDto>.Create(musics, page, PAGE_SIZE);

            return result.ToList();
        }

        List<SearchMusicDto> IMusicSeacrhServices.GetAllByNameArtist(string NameArtist)
        {
            var lists =
                from music in _context.musics
                join artistMusic in _context.artistMusics
                    on music.IdMusic equals artistMusic.IdMusic
                select new { music, IdArtist = artistMusic.IdArtist };
            var result =
                from list in lists
                join artist in _context.artists on list.IdArtist equals artist.IdArtist
                where artist.NameArtist.Equals(NameArtist)
                orderby list.music.NumberLike
                select new SearchMusicDto
                {
                    NameMusic = list.music.NameMusic,
                    ImageMusic = list.music.ImageMusic,
                    LyrcsMusic = list.music.LyrcsMusic,
                    NumberLike = list.music.NumberLike,
                };
            return result.ToList();
        }
    }
}
