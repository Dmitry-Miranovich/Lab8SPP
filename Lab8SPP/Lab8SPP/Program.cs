using System;
using System.Reflection;
using System.IO;

namespace Lab8SPP
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = LoadAssembly();
            WriteAllMembers(assembly);
        }
        private static void WriteAllMembers(Assembly assembly)
        {
            Type[] types = assembly.GetTypes();
            foreach (Type type in types)
            {
                if (CheckTypeForExportAttribute(type))
                {
                    Console.WriteLine($"Класс : {type} \n Поля:");
                    MemberInfo[] members = type.GetMembers();
                    foreach (MemberInfo member in members)
                    {
                        WriteMemberTypeInfo(member);
                    }
                }
            }
        }
        private static bool CheckTypeForExportAttribute(Type type)
        {
            object[] attr = type.GetCustomAttributes(false);
            foreach(object attribute in attr)
            {
                ExportClass curr_attribute = attribute as ExportClass;
                if(curr_attribute != null)
                {
                    return true;
                }
            }
            return false;
        }
        private static void WriteMemberTypeInfo(MemberInfo member)
        {
            switch (member.MemberType)
            {
                case MemberTypes.Field:
                    FieldInfo field = (FieldInfo)member;
                    Console.WriteLine($"Поле :{field.FieldType.Name} {field.Name}"); break;
                case MemberTypes.Property:
                    PropertyInfo property = (PropertyInfo)member;
                    Console.WriteLine($"Свойство :{property.PropertyType.Name} {property.Name}"); break;
                case MemberTypes.Method:
                    MethodInfo method = (MethodInfo)member;
                    Console.WriteLine($"Метод : {method.ReturnType.Name} {method.Name}"); break;
                case MemberTypes.Constructor:
                    Console.WriteLine($"Конструктор : {member.Name}"); break;
                case MemberTypes.Event: Console.WriteLine($"Событие : {member.Name}"); break;
                default: Console.WriteLine($"Другое : {member.Name}"); break;
            }
        }
        private static Assembly LoadAssembly()
        {
            Assembly loadout;
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите полный путь к сборке: ");
                    string path = Console.ReadLine();
                    loadout = Assembly.LoadFrom(path);
                    break;
                }
                catch (FileLoadException ex)
                {
                    Console.WriteLine($"Отказано в доступе. Введите другую сборку.\n Дополнительная информация об ошибке: {ex.Message}");
                }
                catch (BadImageFormatException ex)
                {
                    Console.WriteLine($"Выбран плохой формат для загрузки сборки\n Дополнительная информация об ошибке: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Неизвестная ошибка.\n Дополнительная информация об ошибке: {ex.Message}");
                }
            }
            return loadout;
        }
    }
}
