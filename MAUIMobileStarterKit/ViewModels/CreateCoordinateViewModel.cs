using MAUIMobileStarterKit.Screens.SettingsScreen.CreateCannyonModals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.ViewModels
{
    public class CreateCoordinateViewModel: BaseViewModel
    {
        private readonly AddDescriptionModal addDescriptionModal;
        private readonly AddCoordinatorModal addCoordinatorModal;
        public CreateCoordinateViewModel(AddDescriptionModal addDescriptionModal, AddCoordinatorModal addCoordinatorModal)
        {
            this.addCoordinatorModal = addCoordinatorModal;
            this.addDescriptionModal = addDescriptionModal;
        }

        public AddDescriptionModal GetAddDescriptionModal()
        {
            return addDescriptionModal;
        }

        public AddCoordinatorModal GetAddCoordinatorModal()
        {
            return addCoordinatorModal;
        }
    }
}
