using APBDzad3.Models;

namespace APBDzad3.Repositories
{
    public interface IAnimalRepository
    {
        IEnumerable<Animal> GetAnimals(string orderBy);
        Animal GetAnimal(int id);
        int CreateAnimal(Animal animal);
        int UpdateAnimal(Animal animal);
        int DeleteAnimal(int id);
    }
}