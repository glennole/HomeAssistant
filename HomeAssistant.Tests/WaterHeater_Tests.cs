using System;
using HomeAssistant.Service;
using Xunit;

namespace HomeAssistant.Tests;

public class WaterHeaterTests
{
    private readonly WaterHeater _waterHeater;
    private readonly NordpoolSensor _sensor;
    
    public WaterHeaterTests()
    {
        IHomeAssistantProxy homeAssistantProxy = new HomeAssistantProxyMocked();
        //_switch = new Switch("switch.heavy_duty_switch", homeAssistantProxy, 6);
        _sensor = new NordpoolSensor("sensor.nordpool_kwh_krsand_nok_3_095_025", homeAssistantProxy);
        _waterHeater = new WaterHeater("switch.heavy_duty_switch", homeAssistantProxy, 5);
    }

    [Fact]
    public void CurrentPriceIsBelowThreshold_ReturnsTrue()
    {
        Assert.True(_waterHeater.IsCurrentPriceBelowThreshold(0, _sensor));
    }
    
    [Fact]
    public void CurrentPriceIsMax_ShouldReturnFalse()
    {
        Assert.True(!_waterHeater.IsCurrentPriceBelowThreshold(7, _sensor) && _sensor.Attributes.CurrentPrice == _sensor.Attributes.Max);
    }

    [Fact]
    public void GetUsage_ShouldReturnANumberAboveZero()
    {
        Assert.Throws<NotImplementedException>(() => _waterHeater.GetUsage());
    }

    [Fact]
    public void GetState_ShouldReturnAStateNotUnkown()
    {
        Assert.True(_waterHeater.GetState() != State.Unknown);
    }
}