#include "emptyMessageException.h"


EmptyMessageException::EmptyMessageException() : m_message("")
{

}

EmptyMessageException::EmptyMessageException(const char* message) : m_message(message)
{

}

const char *EmptyMessageException::what() const noexcept {
    return m_message;
}
