using System;
using System.ComponentModel.DataAnnotations;

namespace petshop.Models
{
  public class Cat
  {

    public Cat(string name, string description, int lives)
    {
      Name = name;
      Description = description;
      Lives = lives;
    }

    //NOTE parameterless constructor WAS required for utilizing FromBody on post/put requests to properly map the data over.
    // now we can just use regular constructor because parameterless technically still exists under the hood.
    // public Cat()
    // {
    // }



    [Required]
    [MinLength(3)]
    public string Name { get; set; }
    [MaxLength(25)]
    public string Description { get; set; }
    [Range(0, 9)]
    public int Lives { get; set; }
    public string Id { get; set; } = Guid.NewGuid().ToString();


  }
}