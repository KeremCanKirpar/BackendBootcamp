using System;

namespace Project24_Interface.Interfaces;

public interface IRepo
{
    public  void Create();
    public  void GetAll();
    public  void GetById();
    public  void Update();
    public  void Delete();
}
