using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace rule.engine.Models
{
    public class Rule
    {
        public string Name { get; set; }
        public string Member { get; set; }
        public string Target { get; set; }
        public string Operator { get; set; }

        public Func<T, bool> Compile<T>()
        {
            var subject = Expression.Parameter(typeof(T));

            var expression = MakeExpression<T>(subject);

            return Expression.Lambda<Func<T, bool>>(expression, subject).Compile();
        }

        private Expression MakeExpression<T>(ParameterExpression paramExpression)
        {
            var memberExpression = Expression.Property(paramExpression, Member);
            var propertyType = typeof(T).GetProperty(Member).PropertyType;

            if (Enum.TryParse(Operator, out ExpressionType binary))
            {
                var constant = Expression.Constant(Convert.ChangeType(Target, propertyType));

                return Expression.MakeBinary(binary, memberExpression, constant);
            }
            else
            {
                var method = propertyType.GetMethod(Operator);
                var parameter = method.GetParameters()[0].ParameterType;
                var constant = Expression.Constant(Convert.ChangeType(Target, parameter));

                return Expression.Call(memberExpression, method, constant);
            }
        }

        public override string ToString() => $"{Name}-{Member}-{Target}-{Operator}";
    }
}
