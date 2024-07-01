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


    private async void btnEditar_Clicked(object sender, EventArgs e)
    {

        var button = sender as Button;
        var person = button.BindingContext as persona;
        if (person != null)
        {
            string nuevoNombre = await DisplayPromptAsync("Editar", "Ingrese el nuevo nombre:", initialValue: person.name);
            if (!string.IsNullOrEmpty(nuevoNombre))
            {
                person.name = nuevoNombre;
                App.PersonaRepo.EditPerson(person);
                
                DisplayAlert("Editar", $"Persona con ID: {person.id} editada correctamente", "OK");
                // Refresca la lista después de editar
                btnListar_Clicked(null, null);
            }
        }
    }
    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var person = button.BindingContext as persona;
        if (person != null)
        {
            App.PersonaRepo.DeletePerson(person.id);
            DisplayAlert("Eliminar", $"Persona con ID: {person.id} eliminada correctamente", "OK");
            // Refresca la lista después de eliminar
            btnListar_Clicked(null, null);
        }
        else
        {
            DisplayAlert("Error", "Hubo un error al eliminar la persona", "OK");
        }
    }
   
}