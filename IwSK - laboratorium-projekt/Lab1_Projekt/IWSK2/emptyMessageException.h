#ifndef EMPTYMESSAGEEXCEPTION_H
#define EMPTYMESSAGEEXCEPTION_H
#include <exception>

class EmptyMessageException
        : public std::exception
{
public:
    EmptyMessageException();
    EmptyMessageException(const char*);

private:
    const char* m_message;
public:
    [[nodiscard]] const char *what() const _GLIBCXX_TXN_SAFE_DYN _GLIBCXX_USE_NOEXCEPT override;
};

#endif // EMPTYMESSAGEEXCEPTION_H
