using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception //Aspect
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {

            //defensive coding
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("bu bir dogrulama sinifi degil");
            }

            _validatorType = validatorType;
        }
        //Validation Methoduhn basinda edilir deyene OnBefoe tekce Override edilir
        //Baska aspect metodlarda override edile biler 
        protected override void OnBefore(IInvocation invocation)
        {
            //calisma halinda instance olusdur ( new lemek kimi hansisa bir sinigi) reflectoring ile
            //burada bele instance CreateInstance ile edilir
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            //Basenin validatortypenin yeni productvalidatorun BaseType ile Base sinin 
            //Yeni AbstractValidator<Product> nun GetenericArguments ile [0] indexini Yeni Productu yaxala
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            //metodun invocationin yeni (add update ve sayre)argumentlerini gez Invocation Arguments ile where sorgusu ile Linq
            //egerki ordaki bir tip (entitytype) Product turunde ise onlari validate et
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }


    }


}
