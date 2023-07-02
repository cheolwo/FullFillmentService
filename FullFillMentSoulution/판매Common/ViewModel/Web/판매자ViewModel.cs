using Common.ViewModel;
using Common.ViewService;
using FluentValidation;
using 판매Common.Actor;
using 판매Common.DTO;

namespace 판매Common.ViewModel.Web
{
    public class Create판매자WebViewModel : ActorWebPageViewModel
    {
        public Create판매자WebViewModel(
            판매자ActorCommandContext commandContext, 판매자ActorQueryContext queryContext, ITokenStorage tokenStoage)
            : base(commandContext, queryContext, tokenStoage)
        {
            _판매자DTO = new Create판매자DTO();
            _validator = _actorCommandContext.Set<Create판매자DTO>().GetValidator();
        }
        private Create판매자DTO _판매자DTO;
        public IValidator<Create판매자DTO> _validator;
        public Create판매자DTO 판매자DTO
        {
            get => _판매자DTO;
            set => SetProperty(ref _판매자DTO, value);
        }

        public string Name
        {
            get => _판매자DTO.Name;
            set
            {
                _판매자DTO.Name = value;
                OnPropertyChanged();
            }
        }

        public DateTime CreatedAt
        {
            get => _판매자DTO.CreatedAt;
            set
            {
                if (_판매자DTO.CreatedAt != value)
                {
                    _판매자DTO.CreatedAt = value;
                    OnPropertyChanged();
                }
            }
        }

        public string CenterId
        {
            get => _판매자DTO.CenterId;
            set
            {
                if (_판매자DTO.CenterId != value)
                {
                    _판매자DTO.CenterId = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Address
        {
            get => _판매자DTO.Address;
            set
            {
                if (_판매자DTO.Address != value)
                {
                    _판매자DTO.Address = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ZipCode
        {
            get => _판매자DTO.ZipCode;
            set
            {
                if (_판매자DTO.ZipCode != value)
                {
                    _판매자DTO.ZipCode = value;
                    OnPropertyChanged();
                }
            }
        }

        public string PhoneNumber
        {
            get => _판매자DTO.PhoneNumber;
            set
            {
                if (_판매자DTO.PhoneNumber != value)
                {
                    _판매자DTO.PhoneNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Email
        {
            get => _판매자DTO.Email;
            set
            {
                if (_판매자DTO.Email != value)
                {
                    _판매자DTO.Email = value;
                    OnPropertyChanged();
                }
            }
        }
        public async Task Create판매자()
        {
            try
            {
                await Post(_판매자DTO);
            }
            catch(Exception ex) 
            {

            }
        }
    }

}
