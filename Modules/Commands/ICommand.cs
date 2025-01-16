using System;

namespace TwT
{
  public interface ICommand
  {
    void Execute(string[] args);
  }
}

