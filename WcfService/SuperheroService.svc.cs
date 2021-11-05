namespace WcfService
{
  using System;
  using Common;

  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
  // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
  public class SuperheroService : ISuperheroService
  {
    private readonly SuperheroRepository _repository;

    public SuperheroService()
    {
      this._repository = new SuperheroRepository();
    }

    public string GetData(int value)
    {
      return string.Format("You entered: {0}", value);
    }

    public CompositeType GetDataUsingDataContract(CompositeType composite)
    {
      if (composite == null)
      {
        throw new ArgumentNullException("composite");
      }

      if (composite.BoolValue)
      {
        composite.StringValue += "Suffix";
      }

      return composite;
    }

    public Superhero GetSuperhero()
    {
      return this._repository.GetSuperhero();
    }

    public Superhero[] GetSuperheroes()
    {
      return this._repository.GetSuperheroes();
    }
  }
}