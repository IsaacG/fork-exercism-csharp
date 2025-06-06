public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        {{- if test.expected.error }}
            Assert.Throws<ArgumentException>(() => {{ testedClass }}.{{ test.testedMethod }}({{ test.input.phrase | string.literal }}));
        {{ else }}
            Assert.Equal({{ test.expected | string.literal }}, {{ testedClass }}.{{ test.testedMethod }}({{ test.input.phrase | string.literal }}));
        {{ end -}}
    }
    {{ end -}}
}
