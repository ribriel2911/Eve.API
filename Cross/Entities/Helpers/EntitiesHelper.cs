using Cross.Extensions;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Cross.Entities.Helpers
{
    public class EntitiesHelper
    {
        public static string GetPropertyName<TEntity, TProperty>(Expression<Func<TEntity, TProperty>> exp)
        {
            var memberInfo = ((MemberExpression)exp.Body).Member;
            if (memberInfo == null)
            {
                throw new ArgumentException(
                    "No property reference expression was found.",
                    "propertyExpression");
            }

            var attr = memberInfo.GetAttribute<DisplayNameAttribute>(false);
            if (attr == null)
            {
                return memberInfo.Name;
            }

            return attr.DisplayName;
        }

        public static Type GetPropertyType<TProperty>(Expression<Func<TProperty>> exp)
        {
            var memberInfo = ((MemberExpression)exp.Body).Member;
            if (memberInfo == null)
            {
                throw new ArgumentException(
                    "No property reference expression was found.",
                    "propertyExpression");
            }

            return memberInfo.GetType();
        }
    }
}
