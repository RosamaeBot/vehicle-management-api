# My process for solving this challenge

## Plan out Todolist at the start

:heavy_check_mark: learn how to set up vscode for dotnet core

:heavy_check_mark: learn c# syntax

:heavy_check_mark: relearn object-orieted programming concept

:heavy_check_mark: learn the differences between interface and abstract class

:heavy_check_mark: learn how to design a rest api

:heavy_check_mark: learn how to write tests

:x: learn how to set up CI for dot net core project

:x: learn how to document api

:x: learn to build a cron job console application in dotnet core

## Make a draft for working with Task 1

From relearning OOP, and reading up abstract class and interface, I initially drafted the following design:

```

                 Fleet

              /           \

         Car             Boat

        /    \
 Hatchback    Sedan

A car “is a” Fleet
A boat “is a” Fleet
A hatchback “is a” car
A sedan “is a” car

Common properties:
- Id
- Make
- Model
- Price

```

## 1st Pseudocode draft

```csharp
// Any class that implements IFleet must
// define the following properties
namespace DefineIFleet
{
      using System

      public interface IFleet
      {
        int Id;
        string Make;
        string Model;
        double Price;
        FleetType FleetType;
      }

      class FleetType {
        int id;
        string typename
      }
}

namespace Fleet
{
  using System
  using DefineIFleet

  public abstract class Fleet: IFleet
  {
        public Fleet(string id):
        {

        }

        public string id
        {
            get;
            set;
        }
  }

  public class abstract Car : Fleet
  {
        public Car(string id) : base(id)
        {
        }

        public abstract int Door;
  }

  public class HatchBack : Car
  {
        public HatchBack(string id) : base(id)
        {
        }

        public override int Door;
  }

  public class Sedan : Car
  {
        public Sedan(string id) : base(id)
        {
        }

        public override int Door;
  }

  public abstract class Boat : Fleet
  {
        public Boat(string id) : base(id)
        {
        }
  }
}


```

## For learning how to design an API, I had used this [guide](https://medium.com/@factoryhr/how-to-build-a-good-api-relationships-and-endpoints-8b07aa37097c)

[Database Design]()
