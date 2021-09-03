// using Microsoft.EntityFrameworkCore;

// namespace CBOS.DataModels
// {
//     public static class ModelBuilderExtensions
//     {
//         public static void Seed(this ModelBuilder modelBuilder)
//         {
//             modelBuilder.Entity<ShapeTypes>().HasData(
//                 new ShapeTypes { ShapeTypeId = 1, ShapeType = "Triangles",  NumberOfSides = 3},
//                 new ShapeTypes { ShapeTypeId = 2, ShapeType = "Circles",  NumberOfSides = 1},
//                 new ShapeTypes { ShapeTypeId = 3, ShapeType = "Squares",  NumberOfSides = 4},
//                 new ShapeTypes { ShapeTypeId = 4, ShapeType = "Rectangles",  NumberOfSides = 4},
//                 new ShapeTypes { ShapeTypeId = 5, ShapeType = "Pentagons",  NumberOfSides = 5},
//                 new ShapeTypes { ShapeTypeId = 6, ShapeType = "Hexagons",  NumberOfSides = 6}
//             );

//             modelBuilder.Entity<Shapes>().HasData(
//                 new Shapes { ShapeId = 1,  ShapeType = 1, ShapeName = "Isosceles Triangle"},
//                 new Shapes { ShapeId = 2,  ShapeType = 1, ShapeName = "Equilateral Triangle"},
//                 new Shapes { ShapeId = 3,  ShapeType = 2, ShapeName = "Circle"},
//                 new Shapes { ShapeId = 4,  ShapeType = 3, ShapeName = "Square"},
//                 new Shapes { ShapeId = 5,  ShapeType = 4, ShapeName = "Rectangle"},
//                 new Shapes { ShapeId = 6,  ShapeType = 5, ShapeName = "Pentagon"},
//                 new Shapes { ShapeId = 7,  ShapeType = 6, ShapeName = "Hexagon"},
//                 new Shapes { ShapeId = 8,  ShapeType = 6, ShapeName = "Irregular Hexagon"}
//             ); 
            
//             modelBuilder.Entity<ShapeSides>().HasData(
//                 new ShapeSides { ShapeSideId = 1, ShapeId = 1,  SideLenght = 1},
//                 new ShapeSides { ShapeSideId = 2, ShapeId = 1,  SideLenght = 1},
//                 new ShapeSides { ShapeSideId = 3, ShapeId = 1,  SideLenght = 2},
//                 new ShapeSides { ShapeSideId = 4, ShapeId = 2,  SideLenght = 3},
//                 new ShapeSides { ShapeSideId = 5, ShapeId = 3,  SideLenght = 4},
//                 new ShapeSides { ShapeSideId = 6, ShapeId = 4,  SideLenght = 4},
//                 new ShapeSides { ShapeSideId = 7, ShapeId = 5,  SideLenght = 6},
//                 new ShapeSides { ShapeSideId = 8, ShapeId = 5,  SideLenght = 5},
//                 new ShapeSides { ShapeSideId = 9, ShapeId = 6,  SideLenght = 4},
//                 new ShapeSides { ShapeSideId = 10, ShapeId = 7,  SideLenght = 4},
//                 new ShapeSides { ShapeSideId = 11, ShapeId = 8,  SideLenght = 4},
//                 new ShapeSides { ShapeSideId = 12, ShapeId = 8,  SideLenght = 4},
//                 new ShapeSides { ShapeSideId = 13, ShapeId = 8,  SideLenght = 6},
//                 new ShapeSides { ShapeSideId = 14, ShapeId = 8,  SideLenght = 5},
//                 new ShapeSides { ShapeSideId = 15, ShapeId = 8,  SideLenght = 4},
//                 new ShapeSides { ShapeSideId = 16, ShapeId = 8,  SideLenght = 4}
//             );
//         }
//     }
// }
