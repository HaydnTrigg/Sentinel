#include "Vector2D.hpp"

namespace Sentinel
{
	const Vector2D Vector2D::Zero(0.0f, 0.0f);
	const Vector2D Vector2D::One(1.0f, 1.0f);

	const Vector2D Vector2D::UnitX(1.0f, 0.0f);
	const Vector2D Vector2D::UnitY(0.0f, 1.0f);

	Vector2D::Vector2D(const float x, const float y)
		: X(x), Y(y) {}

	float Vector2D::GetLength() const
	{
		return Length(*this);
	}

	const float Vector2D::Length(const Vector2D &vector2D)
	{
		return Length(vector2D.X, vector2D.Y);
	}

	const float Vector2D::Length(const float x, const float y)
	{
		return sqrt(LengthSquared(x, y));
	}

	float Vector2D::GetLengthSquared() const
	{
		return LengthSquared(*this);
	}

	const float Vector2D::LengthSquared(const Vector2D &vector2D)
	{
		return LengthSquared(vector2D.X, vector2D.Y);
	}

	const float Vector2D::LengthSquared(const float x, const float y)
	{
		return DotProduct(x, y, x, y);
	}

	float Vector2D::GetDistance(const Vector2D &other) const
	{
		return Distance(*this, other);
	}

	const float Vector2D::Distance(const Vector2D &a, const Vector2D &b)
	{
		return Distance(a.X, a.Y, b.X, b.Y);
	}

	const float Vector2D::Distance(const float x1, const float y1, const float x2, const float y2)
	{
		return sqrtf(DistanceSquared(x1, y1, x2, y2));
	}

	float Vector2D::GetDistanceSquared(const Vector2D &other) const
	{
		return DistanceSquared(*this, other);
	}

	const float Vector2D::DistanceSquared(const Vector2D &a, const Vector2D &b)
	{
		return DistanceSquared(a.X, a.Y, b.X, b.Y);
	}

	const float Vector2D::DistanceSquared(const float x1, const float y1, const float x2, const float y2)
	{
		auto x = x1 - x2;
		auto y = y1 - y2;
		return DotProduct(x, y, x, y);
	}

	float Vector2D::GetDotProduct(const Vector2D &other) const
	{
		return DotProduct(*this, other);
	}

	const float Vector2D::DotProduct(const Vector2D &a, const Vector2D &b)
	{
		return DotProduct(a.X, a.Y, b.X, b.Y);
	}

	const float Vector2D::DotProduct(const float x1, const float y1, const float x2, const float y2)
	{
		return (x1 * x2) + (y1 * y2);
	}

	void Vector2D::Normalize()
	{
		operator*=(1.0f / GetLength());
	}

	Vector2D Vector2D::Normalize(const Vector2D &vector2D)
	{
		return vector2D * (1.0f / Length(vector2D));
	}

	void Vector2D::Reflect(const Vector2D &direction)
	{
		operator-=((2.0f * GetDotProduct(direction)) * direction);
	}

	Vector2D Vector2D::Reflect(const Vector2D &position, const Vector2D &direction)
	{
		return position - ((2.0f * DotProduct(position, direction)) * direction);
	}

	Vector2D Vector2D::Min(const Vector2D &a, const Vector2D &b)
	{
		return Vector2D(
			a.X < b.X ? a.X : b.X,
			a.Y < b.Y ? a.Y : b.Y);
	}

	Vector2D Vector2D::Max(const Vector2D &a, const Vector2D &b)
	{
		return Vector2D(
			a.X > b.X ? a.X : b.X,
			a.Y > b.Y ? a.Y : b.Y);
	}

	void Vector2D::Clamp(const Vector2D &min, const Vector2D &max)
	{
		if (X < min.X)
			X = min.X;
		else if (X > max.X)
			X = max.X;
		if (Y < min.Y)
			Y = min.Y;
		else if (Y > max.Y)
			Y = max.Y;
	}

	Vector2D Vector2D::Clamp(const Vector2D &v, const Vector2D &min, const Vector2D &max)
	{
		return Vector2D(
			v.X < min.X ? min.X : v.X > max.X ? max.X : v.X,
			v.Y < min.Y ? min.Y : v.Y > max.Y ? max.Y : v.Y);
	}

	void Vector2D::Lerp(const Vector2D &other, const float amount)
	{
		operator=(Lerp(*this, other, amount));
	}

	Vector2D Vector2D::Lerp(const Vector2D &a, const Vector2D &b, const float amount)
	{
		return a + ((b - a) * amount);
	}

	bool Vector2D::operator==(const Vector2D &other) const
	{
		return X == other.X &&
			Y == other.Y;
	}

	bool Vector2D::operator!=(const Vector2D &other) const
	{
		return X != other.X ||
			Y != other.Y;
	}

	Vector2D &Vector2D::operator-()
	{
		X = -X;
		Y = -Y;
		return *this;
	}

	Vector2D operator+(const Vector2D &lhs, const Vector2D &rhs)
	{
		return Vector2D(lhs.X + rhs.X, lhs.Y + rhs.Y);
	}

	Vector2D operator+(const Vector2D &lhs, const float rhs)
	{
		return Vector2D(lhs.X + rhs, lhs.Y + rhs);
	}

	Vector2D operator+(const float lhs, const Vector2D &rhs)
	{
		return Vector2D(lhs + rhs.X, lhs + rhs.Y);
	}

	Vector2D &Vector2D::operator+=(const Vector2D &other)
	{
		X += other.X;
		Y += other.Y;
		return *this;
	}

	Vector2D &Vector2D::operator+=(const float other)
	{
		X += other;
		Y += other;
		return *this;
	}

	Vector2D operator-(const Vector2D &lhs, const Vector2D &rhs)
	{
		return Vector2D(lhs.X - rhs.X, lhs.Y - rhs.Y);
	}

	Vector2D operator-(const Vector2D &lhs, const float rhs)
	{
		return Vector2D(lhs.X - rhs, lhs.Y - rhs);
	}

	Vector2D operator-(const float lhs, const Vector2D &rhs)
	{
		return Vector2D(lhs - rhs.X, lhs - rhs.Y);
	}

	Vector2D &Vector2D::operator-=(const Vector2D &other)
	{
		X -= other.X;
		Y -= other.Y;
		return *this;
	}

	Vector2D &Vector2D::operator-=(const float other)
	{
		X -= other;
		Y -= other;
		return *this;
	}

	Vector2D operator*(const Vector2D &lhs, const Vector2D &rhs)
	{
		return Vector2D(lhs.X * rhs.X, lhs.Y * rhs.Y);
	}

	Vector2D operator*(const Vector2D &lhs, const float rhs)
	{
		return Vector2D(lhs.X * rhs, lhs.Y * rhs);
	}

	Vector2D operator*(const float lhs, const Vector2D &rhs)
	{
		return Vector2D(lhs * rhs.X, lhs * rhs.Y);
	}

	Vector2D &Vector2D::operator*=(const Vector2D &other)
	{
		X *= other.X;
		Y *= other.Y;
		return *this;
	}

	Vector2D &Vector2D::operator*=(const float other)
	{
		X *= other;
		Y *= other;
		return *this;
	}

	Vector2D operator/(const Vector2D &lhs, const Vector2D &rhs)
	{
		return Vector2D(lhs.X / rhs.X, lhs.Y / rhs.Y);
	}

	Vector2D operator/(const Vector2D &lhs, const float rhs)
	{
		return Vector2D(lhs.X / rhs, lhs.Y / rhs);
	}

	Vector2D operator/(const float lhs, const Vector2D &rhs)
	{
		return Vector2D(lhs / rhs.X, lhs / rhs.Y);
	}

	Vector2D &Vector2D::operator/=(const Vector2D &other)
	{
		X /= other.X;
		Y /= other.Y;
		return *this;
	}

	Vector2D &Vector2D::operator/=(const float other)
	{
		X /= other;
		Y /= other;
		return *this;
	}

	std::istream &operator>>(std::istream &in, Vector2D &vector2D)
	{
		return in
			.read((char *)&vector2D.X, 4)
			.read((char *)&vector2D.Y, 4);
	}

	std::ostream &operator<<(std::ostream &out, Vector2D &vector2D)
	{
		return out
			.write((char *)&vector2D.X, 4)
			.write((char *)&vector2D.Y, 4);
	}
}