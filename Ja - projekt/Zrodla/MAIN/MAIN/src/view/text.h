#pragma once

class Text :
	public Control
{
private:
	std::string text;
	//int x, y;
	int size;
	ALLEGRO_FONT* font;
	bool isInteractive;
public:
	Text(const std::string&, int, int, bool = false, int = 50);
	Text(Text&);
	Text(Text&&) noexcept;
	~Text();

	void draw();
	void doAction();
	void update();

	void setText(const std::string&);

	//void podajWymiary(int* szer, int* wys);
	
};

