using System;
using System.Collections.Generic;
using System.Text;


namespace programe1
{
    public class OrderDateTime
    {
          public int Day { get; set; } 
          public int Month { get; set; } 
          public int Year { get; set; } 
          public OrderDateTime()
          { 
              this.Day = 0; 
              this.Month = 0; 
              this.Year = 0; 
          } 
          public OrderDateTime(int Year, int Month, int Day)
          { 
              this.Day = Day; 
              this.Month = Month; 
              this.Year = Year; 
          } 
          public OrderDateTime(DateTime dateTime)
          { 
              this.Day = dateTime.Day; 
              this.Month = dateTime.Month; 
              this.Year = dateTime.Year; 
          } 
  
 
          public override string ToString()
          { 
              return $"{Year}/{Month}/{Day}"; 
          } 
    }
}
