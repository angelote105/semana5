using semana5.Modelos;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace semana5.Utils
{
    public class PersonaRepositorio
    {
        string dbPath;

        private SQLiteConnection conn;

        public string StatusMeesage { get; set; }

        private void Init()
        {

            if (conn is not null)            
                return;

                conn = new(dbPath);
                conn.CreateTable<persona>();
               // return;
            
        }

        public PersonaRepositorio(string path)
        {

            dbPath = path;
        }

        public void AddNewPerson(string nombre)
        {
            int result = 0;

            try
            {
                Init();

                if (string.IsNullOrEmpty(nombre))
                    throw new Exception("El nombre es requerido");

                persona person = new() { name = nombre };
                result = conn.Insert(person);

                StatusMeesage = string.Format("Dato añadido correctamente", result, nombre);
            }
            catch (Exception EX)
            {
                StatusMeesage = string.Format("Error al insertar", EX.Message);
                
            }

        }

        public List<persona> GetPersonaList() {
            try
            {
                Init ();
                return conn.Table<persona>().ToList();


            }
            catch (Exception EX)
            {

                StatusMeesage = string.Format("Error al Mostrar", EX.Message);

            }
            return new List<persona>();
        }

        
        public void DeletePerson(int id)
        {
            int result = 0;

            try
            {
                Init();

                if (id <= 0)
                    throw new Exception("El ID es requerido y debe ser mayor que 0");

                persona person = conn.Get<persona>(id); // Asumiendo que tienes un método para obtener la persona por ID
                if (person == null)
                    throw new Exception("Persona no encontrada");

                result = conn.Delete(person);

                StatusMeesage = string.Format("Dato eliminado correctamente", result);
            }
            catch (Exception EX)
            {
                StatusMeesage = string.Format("Error al eliminar", EX.Message);
            }
        }

        public void EditPerson(persona person)
        {
            int result = 0;

            try
            {
                Init();

                if (person == null || person.id <= 0)
                    throw new Exception("Persona no válida");

                result = conn.Update(person);

                StatusMeesage = string.Format("Dato editado correctamente", result);
            }
            catch (Exception EX)
            {
                StatusMeesage = string.Format("Error al editar", EX.Message);
            }
        }

    }




}

