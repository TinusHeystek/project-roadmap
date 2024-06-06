using FluentValidation;

namespace ProjectRoadmap.Shared.IOptions.Sample;

public class SampleSettingsValidator : AbstractValidator<SampleSettings>
{
    public SampleSettingsValidator()
    {
        RuleFor(x => x.IntField)
            .InclusiveBetween(0, 100);
        
        RuleFor(x => x.UrlField)
            .NotEmpty()
            .Must(IsValidUrl)
            .When(x => !string.IsNullOrWhiteSpace(x.UrlField))
            .WithMessage($"{nameof(SampleSettings.UrlField)} must be a valid URL.");

        RuleFor(x => x.StringField)
            .NotEmpty();

        RuleFor(x => x.Child)
            .NotNull()
            .SetValidator(new ChildSettingsValidator());

        RuleFor(x => x.IntArray)
            .Must(list => list.Count >= 5)
            .WithMessage($"{nameof(SampleSettings.IntArray)} must have at least 5 items.");

        RuleFor(x => x.StringDictionary)
            .Must(dict => dict.Count >= 2)
            .WithMessage($"{nameof(SampleSettings.StringDictionary)} must have at least 2 items.");

        RuleFor(x => x.DoubleField)
            .InclusiveBetween(1, double.MaxValue);
    }

    private bool IsValidUrl(string url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out _);
    }
}

public class ChildSettingsValidator : AbstractValidator<ChildSettings>
{
    public ChildSettingsValidator()
    {
        RuleFor(x => x.ChildProperty)
            .NotEmpty()
            .WithMessage($"{nameof(ChildSettings.ChildProperty)} is required.");
    }
}