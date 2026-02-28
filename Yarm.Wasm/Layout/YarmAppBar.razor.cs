using System.Net.NetworkInformation;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Yarm.Common.Models;

namespace Yarm.Wasm.Layout;

public partial class YarmAppBar
{
    [Inject] public IDispatcher Dispatcher { get; set; } = null!;
}