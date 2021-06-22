class InitFailException : 
	public std::exception {

public:
	InitFailException(const char* message);

	void writeToFile();

};