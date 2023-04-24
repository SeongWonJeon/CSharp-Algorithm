using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    // 괄호검사기를 만들기
    internal class Stack_Use_Parentheses
    {
        public static bool BracketValidator(string input)
        {
            // 스택 생성
            Stack<char> stack = new Stack<char>();
            

            // 입력 문자열 반복
            foreach (char c in input)
            {
                // 여는 괄호일 경우 스택에 추가
                if (c == '(' || c == '{' || c == '[')
                {
                    stack.Push(c);
                }
                // 닫는 괄호일 경우 스택에서 짝을 이루는 여는 괄호를 제거하고 검사
                else if (c == ')' || c == '}' || c == ']')
                {
                    // 스택이 비어있으면 닫는 괄호와 짝을 이루는 여는 괄호가 없는 것이므로 false 반환
                    if (stack.Count == 0)
                    {
                        return false;
                    }
                    // 스택에서 꺼낸 여는 괄호와 짝이 맞지 않으면 false 반환
                    char open = stack.Pop();
                    if ((c == ')' && open != '(') || (c == '}' && open != '{') || (c == ']' && open != '['))
                    {
                        return false;
                    }
                }
            }

            // 모든 문자열을 검사한 후 스택에 여는 괄호가 남아있으면 false 반환
            return stack.Count == 0;
        }

    }
}
