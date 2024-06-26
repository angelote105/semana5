using semana5.Modelos;

namespace semana5.Vistas;

public partial class vHome : ContentPage
{
	public vHome()
	{
		InitializeComponent();
	}

    private void btnInsertar_Clicked(object sender, EventArgs e)
    {
        Status.Text = "";
        string nombre = txtNombre.Text;
        if (nombre is not null)
        {
            App.PersonaRepo.AddNewPerson(nombre);
            Status.Text = App.PersonaRepo.StatusMeesage;
        }
        else {
            Status.Text = "Campo vacio";
            Status.Text = App.PersonaRepo.StatusMeesage;
        }
        
        
    }

    private void btnListar_Clicked(object sender, EventArgs e)
    {
        Status.Text = "";
        List<persona> people = App.PersonaRepo.GetPersonaList();
        listaPersona.ItemsSource= people;
    }
}