using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens.CanyoningPageScreens;

public partial class ResumeCanyonScreen : ContentView
{
    private readonly CannyonBasedViewModel vm;
    public ResumeCanyonScreen(CannyonBasedViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
        this.vm = viewModel;
        SetupUI();
    }

    private void SetupUI()
    {
       scrollView.HeightRequest = Constans.DeviceHeight-122;
       vm.GetCountriesAsync();
       LoadingComments();
    }

    private async void LoadingComments()
    {
        bool isdataVailable = false;
        var langue = "fr-FR";
        if (langue == "fr-FR" || langue == "fr")
        {
            isdataVailable = await vm.GetCanyonList("fr");
            countryCanyon.Text = vm.CountriesList.Where(c => c.Id == vm.CanyonList[0].CountryId).Select(n => n.NameFr).FirstOrDefault();
        }
        else
        {
            if (langue == "en-EN" || langue == "en" || langue == "en-US")
            {
                countryCanyon.Text = vm.CountriesList.Where(c => c.Id == vm.CanyonList[0].CountryId).Select(n => n.NameEn).FirstOrDefault();
            }
            else
            {
                if (langue == "es-ES" || langue == "es")
                {
                    countryCanyon.Text = vm.CountriesList.Where(c => c.Id == vm.CanyonList[0].CountryId).Select(n => n.NameEs).FirstOrDefault();
                }
                else
                {
                    if (langue == "it-IT" || langue == "it")
                    {
                        countryCanyon.Text = vm.CountriesList.Where(c => c.Id == vm.CanyonList[0].CountryId).Select(n => n.NameIt).FirstOrDefault();
                    }
                    else
                    {
                        countryCanyon.Text = vm.CountriesList.Where(c => c.Id == vm.CanyonList[0].CountryId).Select(n => n.NameEn).FirstOrDefault();
                    }
                }
            }
        }

        if (isdataVailable)
        {

            regionCanyon.Text = vm.CanyonList[0].RegionString;
            stateCanyon.Text = vm.CanyonList[0].Departement;
            cityCanyon.Text = vm.CanyonList[0].Commune;
            mountainCanyon.Text = vm.CanyonList[0].Massif;
            bassinCanyon.Text = vm.CanyonList[0].BassinString;
            riverCanyon.Text = vm.CanyonList[0].Courseau;


            if (vm.CanyonList[0].DcNote != null)
            {
                noteCanyon.Text = vm.CanyonList[0].DcNote.ToString() + "/4";
            }
            else
            {
                noteCanyon.Text = "-";
            }

            if (vm.CanyonList[0].Cotation != null)
            {
                cotationCanyon.Text = vm.CanyonList[0].Cotation.ToString();
            }
            else
            {
                cotationCanyon.Text = "-";
            }

            if (vm.CanyonList[0].Corde != 0)
            {
                cordeCanyon.Text = vm.CanyonList[0].Corde.ToString() + " m";
            }
            else
            {
                cordeCanyon.Text = "-";
            }
       
            if (vm.CanyonList[0].CasMax != 0)
            {
                cascademaxCanyon.Text = vm.CanyonList[0].CasMax.ToString() + " m";
            }
            else
            {
                cascademaxCanyon.Text = "-";
            }
        
            if (vm.CanyonList[0].AltDepart != null)
            {
                altitudeCanyon.Text = vm.CanyonList[0].AltDepart.ToString() + " m";
            }
            else
            {
                altitudeCanyon.Text = "-";
            }

            if (vm.CanyonList[0].Longueur != 0)
            {
                longueurCanyon.Text = vm.CanyonList[0].Longueur.ToString() + " m";
            }
            else
            {
                longueurCanyon.Text = "-";
            }

            if (vm.CanyonList[0].Deniv != 0)
            {
                denivCanyon.Text = vm.CanyonList[0].Deniv.ToString() + " m";
            }
            else
            {
                denivCanyon.Text = "-";
            }

            if (vm.CanyonList[0].ApprocheTime != null)
            {
                approcheCanyon.Text = vm.CanyonList[0].Approchetemps.ToString();
            }
            else
            {
                approcheCanyon.Text = "-";
            }

            if (vm.CanyonList[0].DescenteTime != null)
            {
                descentCanyon.Text = vm.CanyonList[0].Descentetemps.ToString();
            }
            else
            {
                descentCanyon.Text = "-";
            }

            if (vm.CanyonList[0].BackTime != null)
            {
                retourCanyon.Text = vm.CanyonList[0].Retourtemps.ToString();
            }
            else
            {
                retourCanyon.Text = "-";
            }
            if (vm.CanyonList[0].NavetteDistance != null)
            {
                navetteCanyon.Text = vm.CanyonList[0].NavetteDistance.ToString() + " km";
            }
            else
            {
                navetteCanyon.Text = "-";
            }
            if (vm.CanyonList[0].Topographies.Count() != 0)
            {
                obstacleCanyon.Text = vm.CanyonList[0].Topographies.Count().ToString();
            }
            else
            {
                obstacleCanyon.Text = "-";
            }
        }
    }
}