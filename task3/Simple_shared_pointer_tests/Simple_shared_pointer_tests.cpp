#include <gtest/gtest.h>
#include <simple_shared_pointr_impl.hpp>


struct Stub {
	size_t val_;
};

using namespace rt_soft_autumn_school;

TEST(SimpleSharedPtrTest, DefaultConstructTest)
{
	shared_ptr<Stub> ptr(new Stub{ 1 });
	
	EXPECT_TRUE((*ptr).val_ == 1);
}


TEST(SimpleSharedPtrTest, CopyConstructTest)
{
	shared_ptr<Stub> ptr_one(new Stub{ 1 });
	shared_ptr<Stub> ptr_two(ptr_one);

	EXPECT_TRUE((*ptr_two).val_ == 1);
}


TEST(SimpleSharedPtrTest, MoveConstructTest)
{
	shared_ptr<Stub> ptr_one(new Stub{ 1 });
	shared_ptr<Stub> ptr_two(std::move(ptr_one));
	
	EXPECT_TRUE((*ptr_two).val_ == 1);
	EXPECT_TRUE(ptr_one.get() == nullptr);
}