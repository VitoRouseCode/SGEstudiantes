using Microsoft.EntityFrameworkCore;
using SistemaEstudiantes.Core;
using SistemaEstudiantes.Infrastructure;

namespace SistemaEstudiantes.Tests
{
    [TestClass]
    public class EstudianteServiceTests
    {
        [TestMethod]
        public async Task InscribirMaterias_Falla_CuandoSeInscribenMasDe3MateriasConMasDe4Creditos()
        {
            // Arrange: Preparamos el escenario de la prueba
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            var estudiante = new Estudiante { Id = 1, Nombre = "Estudiante de Prueba" };
            var materias = new List<Materia>
            {
                new Materia { Id = 101, Nombre = "Cálculo Avanzado", Creditos = 5 },
                new Materia { Id = 102, Nombre = "Física Cuántica", Creditos = 5 },
                new Materia { Id = 103, Nombre = "Inteligencia Artificial", Creditos = 5 },
                new Materia { Id = 104, Nombre = "Termodinámica", Creditos = 5 }
            };
            var idsMateriasAInscribir = new List<int> { 101, 102, 103, 104 }; // 4 materias de 5 créditos

            // Usamos un contexto de base de datos en memoria
            using (var context = new ApplicationDbContext(options))
            {
                context.Estudiantes.Add(estudiante);
                context.Materias.AddRange(materias);
                await context.SaveChangesAsync();
            }

            bool resultado;
            using (var context = new ApplicationDbContext(options))
            {
                var service = new EstudianteService(context);

                // Act: Ejecutamos la acción que queremos probar
                resultado = await service.InscribirMaterias(estudiante.Id, idsMateriasAInscribir);
            }

            // Assert: Verificamos que el resultado es el esperado
            Assert.IsFalse(resultado, "La inscripción debería fallar porque se excede el límite de créditos.");
        }
    }
}