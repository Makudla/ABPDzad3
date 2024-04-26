using APBDzad3.DTO;
using APBDzad3.Models;
using APBDzad3.Repositories;

namespace APBDzad3.Services
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }
    public class AnimalService(IAnimalRepository animalRepository) : IAnimalService
    {
        
        public IEnumerable<AnimalDto> GetAnimals(string orderBy)
        {
            return animalRepository.GetAnimals(orderBy).Select(a => new AnimalDto
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description,
                Category = a.Category,
                Area = a.Area
            });
        }

        public AnimalDto GetAnimal(int id)
        {
            var animal = animalRepository.GetAnimal(id);

            if (animal == null)
            {
                throw new NotFoundException($"Animal with id {id} not found."); ;
            }

            return new AnimalDto
            {
                Id = animal.Id,
                Name = animal.Name,
                Description = animal.Description,
                Category = animal.Category,
                Area = animal.Area
            };
        }

        public int CreateAnimal(AnimalCreationDto animal)
        {
            if (string.IsNullOrWhiteSpace(animal.Name) ||
            string.IsNullOrWhiteSpace(animal.Description) ||
            string.IsNullOrWhiteSpace(animal.Category) ||
            string.IsNullOrWhiteSpace(animal.Area))
            {
                throw new ArgumentException("Invalid animal data - empty or null");
            }

            return animalRepository.CreateAnimal(new Animal
            {
                Name = animal.Name,
                Description = animal.Description,
                Category = animal.Category,
                Area = animal.Area
            });
        }

        public int UpdateAnimal(int id, AnimalUpdateDto animal)
        {
            return animalRepository.UpdateAnimal(new Animal
            {
                Id = id,
                Name = animal.Name,
                Description = animal.Description,
                Category = animal.Category,
                Area = animal.Area
            });
        }

        public int DeleteAnimal(int id)
        {
            return animalRepository.DeleteAnimal(id);
        }
    }
}
