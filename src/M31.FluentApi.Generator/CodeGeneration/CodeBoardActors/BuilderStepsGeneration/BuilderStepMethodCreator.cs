using M31.FluentApi.Generator.CodeGeneration.CodeBoardActors.MethodCreation.Forks;
using M31.FluentApi.Generator.Commons;

namespace M31.FluentApi.Generator.CodeGeneration.CodeBoardActors.BuilderStepsGeneration;

internal class BuilderStepMethodCreator
{
    internal static IReadOnlyCollection<BuilderStepMethod> CreateBuilderStepMethods(IReadOnlyList<Fork> forks)
    {
        if (forks.Count == 0)
        {
            return Array.Empty<BuilderStepMethod>();
        }

        return new BuilderStepMethodCreator(forks).Create();
    }

    private readonly IReadOnlyList<Fork> forks;
    private readonly Fork firstFork;
    private readonly Dictionary<int, Fork> builderStepToFork;

    private BuilderStepMethodCreator(IReadOnlyList<Fork> forks)
    {
        this.forks = forks;
        firstFork = forks.First();
        builderStepToFork = forks.ToDictionary(f => f.BuilderStep);
    }

    private IReadOnlyCollection<BuilderStepMethod> Create()
    {
        return forks.SelectMany(CreateBuilderStepMethods).ToArray();
    }

    private IEnumerable<BuilderStepMethod> CreateBuilderStepMethods(Fork fork)
    {
        bool isFirstStep = fork == firstFork;

        foreach (ForkBuilderMethod builderMethod in fork.BuilderMethods)
        {
            foreach (BuilderStepMethod builderStepMethod in
                     CreateBuilderStepMethods(isFirstStep, fork.InterfaceName, builderMethod))
            {
                yield return builderStepMethod;
            }
        }
    }

    private BuilderStepMethod[] CreateBuilderStepMethods(
        bool isFirstStep,
        string interfaceName,
        ForkBuilderMethod builderMethod)
    {
        string? nextInterfaceName = GetNextInterfaceName(builderMethod.NextBuilderStep);
        bool isLastStep = nextInterfaceName == null;

        if (isFirstStep && isLastStep)
        {
            return new BuilderStepMethod[]
            {
                new SingleStepBuilderMethod(builderMethod.Value),
                new LastStepBuilderMethod(builderMethod.Value, interfaceName),
            };
        }

        if (isFirstStep)
        {
            return new BuilderStepMethod[]
            {
                new FirstStepBuilderMethod(builderMethod.Value, nextInterfaceName!),
                new InterjacentBuilderMethod(builderMethod.Value, nextInterfaceName!, interfaceName),
            };
        }

        if (isLastStep)
        {
            return new BuilderStepMethod[]
            {
                new LastStepBuilderMethod(builderMethod.Value, interfaceName),
            };
        }

        return new BuilderStepMethod[]
        {
            new InterjacentBuilderMethod(builderMethod.Value, nextInterfaceName!, interfaceName),
        };
    }

    private string? GetNextInterfaceName(int? nextBuilderStep)
    {
        if (nextBuilderStep == null)
        {
            return null;
        }

        if (!builderStepToFork.TryGetValue(nextBuilderStep.Value, out Fork nextFork))
        {
            throw new GenerationException(
                $"Unable to obtain the next fork. Builder step {nextBuilderStep.Value} is unknown.");
        }

        return nextFork.InterfaceName;
    }
}