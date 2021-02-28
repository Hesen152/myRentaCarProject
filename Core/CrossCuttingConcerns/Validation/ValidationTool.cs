using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
  public static class ValidationTool
    {
            //IValidator now =>Product validator because IValidator interface Impelement ProductValidator
            //object entity now =>product 
            public static void Validate(IValidator validator, object entity)
            {
                var context = new ValidationContext<object>(entity);
                // ProductValidator productValidator = new ProductValidator();
                var result = validator.Validate(context);
                if (!result.IsValid)
                {
                    throw new ValidationException(result.Errors);

                }
            }

        }
    }

