﻿using System;
using System.Linq;
using Castle.DynamicProxy;
using FluentValidation;
using SuperTrader.Core.AOF;

namespace SuperTrader.Core.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if ( !typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("WrongValidationType");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            
            var entities = invocation.Arguments.Where(t => t != null && t.GetType() == entityType);
            foreach (var entity in entities)
            {
                var context = new ValidationContext<object>(entity);
                var validationResult = validator.Validate(context);
                if (!validationResult.IsValid)
                {
                    throw new ValidationException(String.Join(", ", validationResult.Errors.Select(f => f.ErrorMessage)));
                }
            }
        }
    }
}
