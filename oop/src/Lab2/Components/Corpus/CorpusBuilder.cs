using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Corpus;

public abstract class CorpusBuilder : ICorpusBuilder
{
    private readonly List<string> _supportedMotherboardFormFactors = new();
    private Dimensions? _maximumVideoCartDimensions;
    private Dimensions? _dimensions;

    public ICorpusBuilder AddSupportedMotherboardFormFactor(string supportedMotherboardFormFactor)
    {
        _supportedMotherboardFormFactors.Add(supportedMotherboardFormFactor);
        return this;
    }

    public ICorpusBuilder WithMaximumVideoCartDimensions(Dimensions maximumVideoCartDimensions)
    {
        _maximumVideoCartDimensions = maximumVideoCartDimensions;
        return this;
    }

    public ICorpusBuilder WithDimensions(Dimensions dimensions)
    {
        _dimensions = dimensions;
        return this;
    }

    public Corpus Build()
    {
        return new Corpus(
            _maximumVideoCartDimensions ?? throw new ArgumentNullException(nameof(_maximumVideoCartDimensions)),
            _supportedMotherboardFormFactors,
            _dimensions ?? throw new ArgumentNullException(nameof(_dimensions)));
    }
}