using AutoMapper;
using Payme.Domain.Entities.Cards;
using Payme.Domain.Entities.PaymentCategories;
using Payme.Domain.Entities.Payments;
using Payme.Domain.Entities.Transactions;
using Payme.Domain.Entities.UserPayments;
using Payme.Domain.Entities.Users;
using Payme.Service.DTOs.Cards;
using Payme.Service.DTOs.PaymentCategories;
using Payme.Service.DTOs.Payments;
using Payme.Service.DTOs.Transactions;
using Payme.Service.DTOs.UserPayments;
using Payme.Service.DTOs.Users;

namespace Payme.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserViewModel>().ReverseMap();
        CreateMap<User, UserCreationModel>().ReverseMap();
        CreateMap<User, UserUpdateModel>().ReverseMap();

        CreateMap<Card, CardViewModel>().ReverseMap();
        CreateMap<Card, CardCreationModel>().ReverseMap();
        CreateMap<Card, CardUpdateModel>().ReverseMap();
        CreateMap<CardViewModel, CardUpdateModel>().ReverseMap();

        CreateMap<Transaction, TransactionViewModel>().ReverseMap();
        CreateMap<Transaction, TransactionCreationModel>().ReverseMap();
        CreateMap<Transaction, TransactionUpdateModel>().ReverseMap();

        CreateMap<Payment, PaymentViewModel>().ReverseMap();
        CreateMap<Payment, PaymentCreationModel>().ReverseMap();
        CreateMap<Payment, PaymentUpdateModel>().ReverseMap();

        CreateMap<UserPayment, UserPaymentCreationModel>().ReverseMap();
        CreateMap<UserPayment, UserPaymentViewModel>().ReverseMap();
        CreateMap<UserPayment, UserPaymentUpdateModel>().ReverseMap();

        CreateMap<PaymentCategory, PaymentCategoryViewModel>().ReverseMap();
        CreateMap<PaymentCategory, PaymentCategoryCreationModel>().ReverseMap();
        CreateMap<PaymentCategory, PaymentCategoryUpdateModel>().ReverseMap();
    }
}
