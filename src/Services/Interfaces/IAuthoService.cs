using Animal_Shelter_V2.src.Models;

using System;
using System.Collections.Generic;
using System.Text;

public interface IAuthoService
{
     UserDto Login(LoginDto loginDto);
}

