# Benchmark


```sh

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.25236.1010)
Intel Core i7-10700K CPU 3.80GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2

```

|         Method |     Mean |    Error |   StdDev |
|--------------- |---------:|---------:|---------:|
|   SimpleIAsync | 21.266 s | 0.0388 s | 0.0363 s |
| PArallelIAsync |  3.109 s | 0.0064 s | 0.0060 s |

*Legends*

- Mean   : Arithmetic mean of all measurements
- Error  : Half of 99.9% confidence interval
- StdDev : Standard deviation of all measurements
- 1 s    : 1 Second (1 sec)