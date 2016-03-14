sampler2D input : register(s0);
// Image to be processed which is loaded from Sampler Register 0.
float maxIter : register(c0);
float2 power : register(c1);
float bailout : register(c2);
float2 offset : register(c3);
float2 size : register(c4);

#include "complex_num.hlsl"

float4 getColor(float i)
{
    float k = 1.0 / 4.0;
    float k2 = 2.0 / 4.0;
    float k3 = 3.0 / 4.0;
    float r = 0.0;
    float g = 0.0;
    float b = 0.0;

    if (i >= k3)
    {
        // Red
        r = 0.86 * i;
        g = 0.20 * i;
        b = 0.21 * i;
    }
    else if (i >= k2)
    {
        // Yellow
        r = 0.96 * i;
        g = 0.76 * i;
        b = 0.05 * i;
    }
    else if (i >= k)
    {
        // Green
        r = 0.24 * i;
        g = 0.73 * i;
        b = 0.33 * i;
    }
    else
    {
        // Blue
        r = 0.28 * i;
        g = .52 * i;
        b = 0.93 * i;
    }
    return float4(r, g, b * 2, 1.0);
}

float4 main(float2 uv : TEXCOORD) : COLOR
// uv are the coordinates of the pixel to be processed
{
    float2 xy = float2(uv.x / size.x + offset.x, uv.y / size.y + offset.y);
    float2 z = float2(xy.x, xy.y); // Complex number z
	float i = 0; // Iterations


	while (i < maxIter && c_abs(z) <= bailout) {
    z = c_add(c_pow(z, power), xy); // Function which recalculates z : z = x^2 + C
    i++; // Iteration count + 1
	}
    if (i < maxIter) {
        i -= log(log(c_abs(z))) / log(c_abs(power)); // Equation is "n = -(log(log(|z|)) / log(|P|))"
        return getColor(i / maxIter);
    }
    else
        return float4(0.0, 0.0, 0.0, 1.0);
}