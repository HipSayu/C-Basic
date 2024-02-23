using System;
using AppMobileBackEnd.DbContexts;
using AppMobileBackEnd.Dtos.Music;
using AppMobileBackEnd.Entity;
using AppMobileBackEnd.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppMobileBackEnd.Services.Implements
{
    public class MusicServices : IMusciServices
    {
        private readonly ApplicationMyDBContext _context;

        public MusicServices(ApplicationMyDBContext context)
        {
            _context = context;
        }

        public void Create(CreateMusicDto input)
        {
            _context.musics.Add(
                new Music
                {
                    NameMusic = input.NameMusic,
                    DataMusic = input.DataMusic,
                    DesriptionMusic = input.DesriptionMusic,
                    ImageMusic = input.ImageMusic,
                    LyrcsMusic = input.LyrcsMusic,
                    NumberLike = input.NumberLike,
                }
            );
            _context.SaveChanges();
        }



        public void Delete(int IdMusic)
        {
             var music = _context.musics.SingleOrDefault(m => m.IdMusic == IdMusic);
            if (music == null)
            {
                throw new NotImplementedException($"Không music có  nào có id {IdMusic}");
            }
            _context.musics.Remove(music);
            _context.SaveChanges();
        }

        public List<MusicDto> GetAll()
        {
            var musics = _context.musics.Select(m => new MusicDto
            {
                IdMusic = m.IdMusic,
                NameMusic = m.NameMusic,
                DataMusic = m.DataMusic,
                DesriptionMusic = m.DesriptionMusic,
                ImageMusic = m.ImageMusic,
                LyrcsMusic = m.LyrcsMusic,
                NumberLike = m.NumberLike,
            });
            return musics.ToList();
        }

        public List<MusicDto> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public MusicDto GetBySingerName(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(UpdateMusicDto input)
        {
            var music = _context.musics.SingleOrDefault(m => m.IdMusic == input.IdMusic);
            if (music == null)
            {
                throw new NotImplementedException($"Không music có  nào có id {input.IdMusic}");
            }
            music.NameMusic = input.NameMusic;
            music.DataMusic = input.DataMusic;
            music.DesriptionMusic = input.DesriptionMusic;
            music.ImageMusic = input.ImageMusic;
            music.LyrcsMusic = input.LyrcsMusic;
            music.NumberLike = input.NumberLike;
            _context.SaveChanges();
        }
    }
}
