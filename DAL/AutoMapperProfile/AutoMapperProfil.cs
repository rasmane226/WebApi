using AutoMapper;
using DAL.Dtos.BolumlerDtos;
using DAL.Dtos.DepocikisiDtos;
using DAL.Dtos.DepogirisiDtos;
using DAL.Dtos.MarkalarDtos;
using DAL.Dtos.ModellerDtos;
using DAL.Dtos.UrunlerDtos;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.AutoMapperProfile
{
    public class AutoMapperProfil: Profile
    {
        public AutoMapperProfil() 
        {
            CreateMap<Bolumler, CreateBolumlerDtos>().ReverseMap();
            CreateMap<Bolumler, UpdateBolumlerDtos>().ReverseMap();

            CreateMap<Urunler, CreateUrunlerDtos>().ReverseMap();
            CreateMap<Urunler, UpdateUrunlerDtos>().ReverseMap();

            CreateMap<Markalar, CreateMarkalarDtos>().ReverseMap();
            CreateMap<Markalar, UpdateMarkalarDtos>().ReverseMap();

            CreateMap<Modeller, CreateModellerDtos>().ReverseMap();
            CreateMap<Modeller, UpdateModellerDtos>().ReverseMap();

            CreateMap<Depogirisi, CreateDepogirisiDtos>().ReverseMap();
            CreateMap<Depogirisi, UpdateDepogirisiDtos>().ReverseMap();

            CreateMap<Depocikisi, CreateDepocikisiDtos>().ReverseMap();
            CreateMap<Depocikisi, UpdateDepocikisiDtos>().ReverseMap();

                //.ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
                //.ForMember(dest => dest.Ad, opt => opt.MapFrom(src => src.Ad))
                //.ForMember(dest => dest.Aktif, opt => opt.MapFrom(src => src.Aktif));
        }
    }
}
