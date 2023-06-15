using StackExchange.Redis;
using System;
using System.Reflection.Emit;
using System.Reflection;


public interface IApiService
{
    void SomeMethod(string value);
    // 다른 필요한 메서드들을 선언할 수 있습니다.
}

public class MyController : IApiService
{
    public void SomeMethod(string value)
    {
        Console.WriteLine(value);
    }

    // 다른 필요한 액션 메서드들을 선언할 수 있습니다.
}

public class APIServiceGenerator
{
    public object GenerateAPIServiceForController(Type controllerType)
    {
        Type apiServiceType = GenerateAPIServiceType(controllerType);

        object apiServiceInstance = Activator.CreateInstance(apiServiceType);

        return apiServiceInstance;
    }

    private Type GenerateAPIServiceType(Type controllerType)
    {
        TypeBuilder typeBuilder = CreateTypeBuilder();
        typeBuilder.AddInterfaceImplementation(typeof(IApiService));

        ImplementInterfaceMethods(typeBuilder, controllerType);

        Type generatedType = typeBuilder.CreateType();
        return generatedType;
    }

    private TypeBuilder CreateTypeBuilder()
    {
        AssemblyName assemblyName = new AssemblyName("DynamicAssembly");
        AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
        ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("DynamicModule");
        TypeBuilder typeBuilder = moduleBuilder.DefineType("DynamicAPIService", TypeAttributes.Public);
        return typeBuilder;
    }

    private void ImplementInterfaceMethods(TypeBuilder typeBuilder, Type controllerType)
    {
        MethodInfo[] methods = controllerType.GetMethods();

        foreach (MethodInfo method in methods)
        {
            if (method.IsPublic && !method.IsSpecialName)
            {
                ParameterInfo[] parameters = method.GetParameters();
                Type[] parameterTypes = parameters.Select(p => p.ParameterType).ToArray();

                MethodBuilder methodBuilder = typeBuilder.DefineMethod(
                    method.Name,
                    MethodAttributes.Public | MethodAttributes.Virtual,
                    method.ReturnType,
                    parameterTypes);

                ILGenerator ilGenerator = methodBuilder.GetILGenerator();
                for (int i = 0; i < parameters.Length; i++)
                {
                    ilGenerator.Emit(OpCodes.Ldarg, i + 1);
                }
                ilGenerator.Emit(OpCodes.Call, method);
                ilGenerator.Emit(OpCodes.Ret);
            }
        }
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        Type controllerType = typeof(MyController);
        APIServiceGenerator apiServiceGenerator = new APIServiceGenerator();
        object apiService = apiServiceGenerator.GenerateAPIServiceForController(controllerType);

        // 생성된 APIService 사용
        IApiService apiServiceInstance = (IApiService)apiService;
        apiServiceInstance.SomeMethod("asdf");
    }
}
